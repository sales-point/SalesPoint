import React from 'react'

import { Carousel } from 'react-responsive-carousel'
import WorkTimeBanner from '../../images/worktime_banner.png'
import DiscountBanner from '../../images/discount_banner.png'

// general styles
import 'style-loader!css-loader!react-responsive-carousel/lib/styles/main.css'

// carousel styles
import 'style-loader!css-loader!react-responsive-carousel/lib/styles/carousel.css'

const NewsCarousel = () => {
  return (
    <div>
      <Carousel
        autoplay={true}
        infiniteLoop
        stopOnHover={false}
        showThumbs={false}
        showStatus={false}
      >
        <div>
          <img src={WorkTimeBanner} />
        </div>
        <div>
          <img src={DiscountBanner} />
        </div>
      </Carousel>
    </div>
  )
}
export default NewsCarousel
